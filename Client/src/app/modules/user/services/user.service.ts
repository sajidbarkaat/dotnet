import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private httpClient: HttpClient) { }
    
    getAll(): Observable<any> {
        return this.httpClient.get('https://localhost:5000/api/user/all');
    }
}