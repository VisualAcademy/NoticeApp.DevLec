using Microsoft.AspNetCore.Components;
using NoticeApp.Models;
using NoticeApp.Pages.Notices.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeApp.Pages.Notices
{
    public partial class Manage
    {
        [Inject]
        public INoticeRepositoryAsync NoticeRepositoryAsyncReference { get; set; }

        [Inject]
        public NavigationManager NavigationManagerReference { get; set; }

        public EditorForm EditorFormReference { get; set; }

        public DeleteDialog DeleteDialogReference { get; set; }

        protected List<Notice> models;

        protected Notice model = new Notice(); 

        protected DulPager.DulPagerBase pager = new DulPager.DulPagerBase()
        {
            PageNumber = 1,
            PageIndex = 0,
            PageSize = 2,
            PagerButtonCount = 5
        };

        protected override async Task OnInitializedAsync()
        {
            await DisplayData();
        }

        private async Task DisplayData()
        {
            //await Task.Delay(3000);
            var resultsSet = await NoticeRepositoryAsyncReference.GetAllAsync(pager.PageIndex, pager.PageSize);
            pager.RecordCount = resultsSet.TotalRecords;
            models = resultsSet.Records.ToList();

            StateHasChanged();
        }

        protected void NameClick(int id)
        {
            NavigationManagerReference.NavigateTo($"/Notices/Details/{id}");
        }

        protected async void PageIndexChanged(int pageIndex)
        {
            pager.PageIndex = pageIndex;
            pager.PageNumber = pageIndex + 1;

            await DisplayData();
        }

        public string EditorFormTitle { get; set; } = "CREATE";

        protected void ShowEditorForm()
        {
            EditorFormTitle = "CREATE";
            this.model = new Notice(); 
            EditorFormReference.Show();
        }

        protected void EditBy(Notice model)
        {
            EditorFormTitle = "EDIT";
            this.model = model; 
            EditorFormReference.Show();
        }

        protected void DeleteBy(Notice model)
        {
            this.model = model;
            DeleteDialogReference.Show();    
        }

        protected async void CreateOrEdit()
        {
            EditorFormReference.Hide();
            await DisplayData();            
        }

        protected async void DeleteClick()
        {
            await NoticeRepositoryAsyncReference.DeleteAsync(this.model.Id);
            DeleteDialogReference.Hide();
            this.model = new Notice(); 
            await DisplayData();
        }
    }
}
