import { NgModule } from "@angular/core";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { TokenInterceptor } from "./interceptors/token.interceptor";
import { ErrorInterceptor } from "./interceptors/error.interceptor";

@NgModule({
    declarations: [],
    imports: [],
    exports: [],
    providers: [      
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},  
        { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true}
    ]
})
export class CoreModule{}