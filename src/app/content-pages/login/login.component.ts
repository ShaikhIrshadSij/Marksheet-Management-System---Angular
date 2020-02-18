import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/core/auth/auth.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  username: string;
  password: string;
  returnUrl: string;

  constructor(private router: Router,
    private route: ActivatedRoute, private authenticationService: AuthenticationService) {
      if(authenticationService.isLoggedIn()){
        this.router.navigate(['dashboard']);
      }
      this.username = "irshadshaikh.vision@gmail.com";
      this.password = "Admin@123";
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onLogin(): void {
    this.authenticationService.login(this.username, this.password)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          console.log(error);
        });
  }
  // On Forgot password link click
  onForgotPassword() {
    this.router.navigate(['forgotpassword'], { relativeTo: this.route.parent });
  }
  // On registration link click
  onRegister() {
    this.router.navigate(['register'], { relativeTo: this.route.parent });
  }

}
