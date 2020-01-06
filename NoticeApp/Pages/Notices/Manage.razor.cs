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
        [Parameter]
        public int ParentId { get; set; } = 0;

        [Inject]
        public INoticeRepositoryAsync NoticeRepositoryAsyncReference { get; set; }

        [Inject]
        public NavigationManager NavigationManagerReference { get; set; }

        public EditorForm EditorFormReference { get; set; }

        public DeleteDialog DeleteDialogReference { get; set; }

        protected List<Notice> models;

        protected Notice model = new Notice();

        /// <summary>
        /// 공지사항으로 올리기 폼을 띄울건지 여부 
        /// </summary>
        public bool IsInlineDialogShow { get; set; } = false; 

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
            if (ParentId == 0)
            {
                //await Task.Delay(3000);
                var resultsSet = await NoticeRepositoryAsyncReference.GetAllAsync(pager.PageIndex, pager.PageSize);
                pager.RecordCount = resultsSet.TotalRecords;
                models = resultsSet.Records.ToList();
            }
            else
            {
                var resultsSet = await NoticeRepositoryAsyncReference.GetAllByParentIdAsync(pager.PageIndex, pager.PageSize, ParentId);
                pager.RecordCount = resultsSet.TotalRecords;
                models = resultsSet.Records.ToList();
            }

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

        protected void ToggleBy(Notice model)
        {
            this.model = model;
            IsInlineDialogShow = true; 
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

        protected void ToggleClose()
        {
            IsInlineDialogShow = false;
            this.model = new Notice(); 
        }

        protected async void ToggleClick()
        {
            this.model.IsPinned = (this.model?.IsPinned == true) ? false : true; 

            await NoticeRepositoryAsyncReference.EditAsync(this.model);
            IsInlineDialogShow = false; 
            this.model = new Notice();
            await DisplayData();
        }
    }
}
