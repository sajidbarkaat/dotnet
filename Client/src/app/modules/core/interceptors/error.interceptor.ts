import { Injectable } from "@angular/core";
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable, throwError } from "rxjs";
import { NavigationExtras, Router } from "@angular/router";

@Injectable({
providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {  
    constructor(private router: Router) {}

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return next.handle(request).pipe(
            catchError(error => {
                if(error) {
                    switch(error.status) {                        
                        case 400:
                            if(error.error.errors) {    
                                const modelStateErrors = [];
                                for (const key in error.error.errors) {
                                    modelStateErrors.push(error.error.errors[key]);
                                }

                                throw modelStateErrors;
                            } else {
                                //
                            }

                            break;
                        case 401:
                            break;
                        case 500:
                            const navigationExtras: NavigationExtras = { state: {error}};
                            this.router.navigateByUrl('/error-page', navigationExtras);
                            break;
                        default:
                            break;
                    }
                }

                return throwError(() => error);
            })
        )
    }
}