import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ILoginCredentialsDto } from "./dtos/login-credentials.dto";

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    bearerToken!: string;
    readonly TOKEN_NAME: string = 'bearer-token';

    constructor(private httpClient: HttpClient) { }    
   
    authenticate(loginCredentialsDo: ILoginCredentialsDto): void
    {
        this.httpClient.post('https://localhost:5000/api/account/login', loginCredentialsDo)
        .subscribe({
            next: response => {
                console.log(response);
                this.bearerToken = response.toString();
                localStorage.setItem(this.TOKEN_NAME, this.bearerToken);
            }
        });
    }

    isLoggedIn(): boolean {
        return !!(this.getToken());
    }

    getToken(): string | null {
        return this.bearerToken || localStorage.getItem(this.TOKEN_NAME);
    }
}