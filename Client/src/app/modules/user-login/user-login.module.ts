import { NgModule, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthenticationService } from "../core/authentication.service";
import { SharedModule } from "../shared/shared.module";
import { UserLoginComponent } from "./user-login.component";

@NgModule({
    declarations:[UserLoginComponent],
    imports:[SharedModule],
    exports
})
export class LoginModule implements OnInit {
    loginForm!: FormGroup;

    constructor(private authenticationService: AuthenticationService){}

    ngOnInit(): void {
        this.loginForm = new FormGroup({
            username: new FormControl('', [Validators.required]),
            password: new FormControl('', [Validators.required])
        });                
    }

    onLoginHandler(): void {
        
    }
}