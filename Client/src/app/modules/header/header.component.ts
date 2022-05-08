import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../core/authentication.service';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
    public isLoggedIn!: boolean;

    constructor(private authenticationService: AuthenticationService) {}  

    ngOnInit(): void {
        this.isLoggedIn = this.authenticationService.isAuthenticated();
    }
}
