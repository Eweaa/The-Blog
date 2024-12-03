export class Article
{
  id?: string;
  articleImg?: string;
  content?: string;
  title?: string;
  userEmail?: string;
  userName?: string;
  userImg?: string;
  date?: string;

  constructor(id: string, articleImg: string, content: string, title: string, userEmail: string, userName: string, userImg: string)
  {
    this.id = id;
    this.articleImg = articleImg;
    this.content = content;
    this.title = title;
    this.userEmail = userEmail;
    this.userName = userName;
    this.userImg = userImg;
    this.userName = userName;
    this.userImg = userImg;
    this.date = Date.now().toString();
  }
}
