import { Routes } from "@angular/router";
import {HomeComponent} from "./Pages/home/home.component";
import {BookmarksComponent} from "./Pages/bookmarks/bookmarks.component";
import {ProfileComponent} from "./Pages/profile/profile.component";
import {ArticleComponent} from "./Pages/article/article.component";

export const containerRoutes: Routes =
  [
    { path: "", component: HomeComponent },
    { path: "Bookmarks", component: BookmarksComponent },
    { path: "Profile/:UserName", component: ProfileComponent },
    { path: "Article/:Id", component: ArticleComponent },
  ];
