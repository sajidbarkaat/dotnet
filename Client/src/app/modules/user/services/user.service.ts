import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IRegisterDto } from "../../core/dtos/register.dto";

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private httpClient: HttpClient) { }
    
    getAll(): Observable<any> {
        return this.httpClient.get('https://localhost:5000/api/user/all');
    }

    register(registerDto: IRegisterDto): void
    {
        this.httpClient.post('https://localhost:5000/api/account/signup', registerDto)
        .subscribe({
            next: response => {
                console.log(response);
                localStorage.setItem("token", response.toString());
            }
        });
    }
}