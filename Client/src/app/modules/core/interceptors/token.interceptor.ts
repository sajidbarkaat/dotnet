import { Injectable } from "@angular/core";
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable, throwError } from "rxjs";
import { NavigationExtras, Router } from "@angular/router";
import { AuthenticationService } from "../authentication.service";

@Injectable({
providedIn: 'root'
})
export class TokenInterceptor implements HttpInterceptor {  
    constructor(private router: Router, private authService: AuthenticationService) {}

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        const authToken: string | null = this.authService.getToken();

        if(authToken) {
            request = request.clone({headers: request.headers.set('Authorization', `Bearer ${authToken}`)});
        }

        return next.handle(request);
    }
}