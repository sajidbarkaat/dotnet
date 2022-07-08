import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../core/authentication.service';

@Component({
  selector: 'header-component',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    public isLoggedIn!: boolean;

    constructor(private authenticationService: AuthenticationService, private router: Router) {}  

    ngOnInit(): void {
        this.isLoggedIn = this.authenticationService.isLoggedIn();
    }

    public gotoSignupHandler(): void {
      debugger;
      console.log('going to singup');
      this.router.navigateByUrl('/user/signup');
    }
}