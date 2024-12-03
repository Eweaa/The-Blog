import {Article} from "./Article";

export interface ProfileData
{
  userName: string;
  userImg: string;
  articles: Array<Article>;
  isFollowd: boolean;
}
