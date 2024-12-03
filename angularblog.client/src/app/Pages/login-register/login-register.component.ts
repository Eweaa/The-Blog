import {Component, OnDestroy, OnInit} from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  ValidationErrors,
  Validators
} from "@angular/forms";
import {CommonModule} from "@angular/common";
import {Router} from "@angular/router";
import {AccountService} from "../../Services/account.service";
import {RegisterDto} from "../../Models/RegisterDto";
import {Subscription} from "rxjs";
import {LoginDto} from "../../Models/LoginDto";
import {jwtDecode} from "jwt-decode";
import {LoginResponse} from "../../Models/LoginResponse";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-login-register',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login-register.component.html',
  styleUrl: './login-register.component.css'
})
export class LoginRegisterComponent implements OnInit, OnDestroy
{
  accountSub: Subscription | null = null;
  RegisterForm: FormGroup;
  LoginForm: FormGroup;
  RegisterData!: RegisterDto;
  LoginData!: LoginDto;
  Form: boolean = true;

  constructor(private router: Router, private account: AccountService, private toastr: ToastrService)
  {
    this.RegisterForm = new FormGroup({
      'displayName': new FormControl(null, [Validators.required]),
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required, Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$')]),
      'confirmPassword': new FormControl(null, [Validators.required, Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$')])
    }, this.passwordMatchValidator);

    this.LoginForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required, Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$')])
    })
  }

  ngOnDestroy(): void
  {
    if(this.accountSub)
    {
      this.accountSub.unsubscribe();
    }
  }

  ngOnInit(): void
  {
  }

  onSubmit()
  {
    this.RegisterData = this.RegisterForm.value;
    if(this.RegisterForm.valid)
    {
      this.accountSub = this.account.Register(this.RegisterData).subscribe({
        next: (result) => {
          console.log(result);
          this.router.navigateByUrl("/");
        },
        error: err => {
          console.log(err);
        }
      })
    }
    else
    {
      alert("Not Validated")
    }
  }

  login()
  {
    this.LoginData =  this.LoginForm.value;
    this.accountSub = this.account.Login(this.LoginData).subscribe({
      next: (res: LoginResponse) => {

        let token = res.token;
        let data: {Email: string, Name: string } = jwtDecode(token);

        localStorage.setItem("token", token);
        localStorage.setItem("Email", data.Email);
        localStorage.setItem("Name", data.Name);

        this.toastr.success("Logged in Successfully", "Success", { positionClass: "toast-bottom-right" });

        this.router.navigateByUrl("/");
      },
      error: err => {
        console.log(err);
        this.toastr.error("You've Entered Something Wrong", "Failed", { positionClass: "toast-bottom-right" });
      }
    })
  }

  getLoginForm()
  {
    this.Form = false;
    this.RegisterForm.reset();
  }

  getRegisterForm()
  {
    this.Form = true;
    this.LoginForm.reset();
  }

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null
  {
    return control.get('password')?.value == control.get('confirmPassword')?.value ? null : { PasswordNoMatch: true };
  }

}
