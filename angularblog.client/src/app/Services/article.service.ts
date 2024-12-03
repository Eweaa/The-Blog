import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Article} from "../Models/Article";

@Injectable({
  providedIn: 'root'
})
export class ArticleService
{

  constructor(private http: HttpClient) { }


  getArticleById(Id: string)
  {
    return this.http.get<Article>("https://localhost:44377/api/Article/GetArticleById", { params: { articleId: Id } })
  }

  createArticle(Article: any)
  {
    console.log("From Article Service", Article);
    return this.http.post("https://localhost:44377/api/Article/CreateArticle", Article);
  }

  addBookmark(articleId: string)
  {
    return this.http.post(`https://localhost:44377/api/Account/AddBookmark`, null, { params: {articleId} });
  }

  removeBookmark(articleId: string)
  {
    return this.http.delete("https://localhost:44377/api/Account/RemoveBookmark", { params: { articleId: articleId } } );
  }

  getBookmarks()
  {
    return this.http.get<any>("https://localhost:44377/api/Account/GetBookmarks");
  }
}
