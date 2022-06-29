import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthenticationService } from "../../core/authentication.service";

@Component({
    selector:'user-login',
    templateUrl:'./user-login.component.html',
    styleUrls:['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
    loginForm!: FormGroup;

    constructor(private authenticationService: AuthenticationService, private router: Router){}

    ngOnInit(): void {
        this.loginForm = new FormGroup({
            username: new FormControl('', [Validators.required]),
            password: new FormControl('', [Validators.required])
        });                
    }

    onLoginHandler(): void {
        //this.loginForm.value        
        if(this.loginForm.invalid) {
            return;
        }
        
        this.router.navigateByUrl('/');
    }
}