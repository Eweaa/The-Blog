import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Article} from "../Models/Article";

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  getArticles()
  {
    return this.http.get<Array<Article>>("https://localhost:44377/api/Article/GetAllArticles")
  }

  getHomeArticles()
  {
    // let user = localStorage.getItem("user");
    return this.http.get<Array<Article>>("https://localhost:44377/api/Article/GetHomeArticles")
  }
}
