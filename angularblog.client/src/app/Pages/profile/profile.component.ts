import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {ProfileService} from "../../Services/profile.service";
import {Subscription} from "rxjs";
import {ArticleCardComponent} from "../../Components/article-card/article-card.component";
import {Article} from "../../Models/Article";
import {ToastrService} from "ngx-toastr";
import {CommonModule} from "@angular/common";
import {ArticleService} from "../../Services/article.service";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {ProfileArticleCardComponent} from "../../Components/profile-article-card/profile-article-card.component";
import {ProfileData} from "../../Models/ProfileData";
import {AccountService} from "../../Services/account.service";

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [
    ArticleCardComponent,
    CommonModule,
    ReactiveFormsModule,
    ProfileArticleCardComponent,
  ],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit, OnDestroy
{
  constructor
  (
    private activatedRoute: ActivatedRoute,
    private profileService: ProfileService,
    private articleService: ArticleService,
    private toastr: ToastrService,
    private router: Router,
    private accountService: AccountService
  ) { }

  articlesSub: Subscription | null = null;
  profileData!: ProfileData;
  articles: Array<Article> = [];
  imageFile!: File;
  articleForm!: FormGroup;
  MyProfile!: boolean;
  newPost: boolean = false;

  ngOnInit(): void
  {
    this.articleForm = new FormGroup({
      'title': new FormControl(""),
      'content': new FormControl(""),
      'image': new FormControl(null),
    })

    this.loadData();
  }

  loadData(): void
  {
    this.articlesSub = this.activatedRoute.params.subscribe(params => {
      this.profileService.getArticles(params['UserName']).subscribe({
        next: res => {
          console.log(res);
          this.profileData = res;
          // this.articles = res.articles;
          (localStorage.getItem("Name") == params['UserName']) ? this.MyProfile = true : this.MyProfile = false;
        },
        error: err => {
          this.toastr.error("Failed to load articles");
        }
      })
    })
  }


  // toggleNewPost = () => this.newPost = !this.newPost;

  toggleNewPost()
  {
    this.newPost = !this.newPost;
  }


  getImage(event: any)
  {
    this.imageFile = event.target.files[0];
    this.articleForm.patchValue({
      'image': this.imageFile
    })
  }

  onSubmit()
  {
    const formData = new FormData();

    formData.append("title", this.articleForm.value.title);
    formData.append("content", this.articleForm.value.content);
    formData.append("image", this.articleForm.value.image);

    this.articleService.createArticle(formData).subscribe({
      next: () => {
        this.toastr.success("Article created successfully.");
      },
      error: (err) => {
        console.log(err);
        this.toastr.error("Failed to create the article");
      }
    })
  }

  Follow()
  {
    this.activatedRoute.params.subscribe(params => {
      this.accountService.Follow(params['UserName']).subscribe({
        next: res => {
          console.log(res);
          this.loadData();
          this.toastr.success(``, `Followed ${this.profileData.userName}`, { positionClass: "toast-bottom-right" });
        },
        error: err => {
          console.log(err);
        }
      })
    })
  }

  Unfollow()
  {
    this.activatedRoute.params.subscribe(params => {
      this.accountService.Unfollow(params['UserName']).subscribe({
        next: res => {
          console.log(res);
          this.loadData();
          this.toastr.success(``, `Unfollowed ${this.profileData.userName}`, { positionClass: "toast-bottom-right" });
        },
        error: err => {
          console.log(err);
        }
      })
    })
  }

  ngOnDestroy(): void
  {
    this.articlesSub!.unsubscribe();
  }

  // protected readonly indexedDB = indexedDB;
}
