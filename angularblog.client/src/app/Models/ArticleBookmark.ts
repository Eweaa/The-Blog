import {Article} from "./Article";

export interface ArticleBookmark extends Article
{
  isBookmarked: boolean;
}
