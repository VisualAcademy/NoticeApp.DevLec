# NoticeApp
공지사항 앱 만들기 개발, 강의, 집필 관련 소스 모음

## 01. NoticeApp 솔루션 생성 및 NoticeApp.SqlServer 이름의 SQL Server 데이터베이스 프로젝트 생성 후 GitHub에 게시

기본형 게시판을 확장하여 공지사항 앱을 만들기 시작합니다. 데이터베이스 프로젝트를 만들고 테이블을 생성합니다.

**공지사항**, __NoticeApp__, **Notices**

## 02. Notices 테이블과 일대일로 매핑되는 Notice 모델 클래스 생성

닷넷스탠다드 프로젝트를 생성 후 테이블과 일대일로 매핑되는 모델 클래스를 생성합니다.

**모델**, __Notice__, **CRUD**

## 03. 리포지토리 인터페이스 및 클래스 기본 모양 구현하기

데이터 처리를 위한 기본 메서드에 대한 코드를 리포지토리 인터페이스와 클래스로 구현합니다.

**리포지토리**, __Repository__, **IRepository**

## 04. Repository 클래스에 생성자로 DbContext 주입 후 AddAsync 메서드의 기본 코드 작성

리포지토리 클래스에 DbContext 클래스를 주입한 후 입력 메서드에 대한 코드를 완성합니다.

**DI**, __의존성주입__, **AddAsync**

## 05. NoticeRepositoryAsyncTest_MSTest 프로젝트 생성 및 AddAsync 메서드 테스트

공식과같은 방식으로 데이터를 입력하는 Add 메서드를 작성하고 MSTest 프로젝트를 생성하고 테스트 메서드를 작성합니다.

**입력**, __AddAsync__, **AddAsyncTest**

## 06. GetAll 메서드 코드 구현 및 테스트 코드 생성 후 테스트 완료

전체 데이터를 출력하는 GetAll 메서드를 작성하고 이를 테스트하는 메서드를 작성합니다.

**출력**, __GetAll__, **GetAllTest**

## 07. GetById 메서드 코드 구현 및 테스트 코드 생성 후 테스트 완료

하나의 데이터에 대한 상세보기를 제공하는 GetById 메서드 작성 및 테스트를 진행합니다. 

**상세**, __GetById__, **GetById**

