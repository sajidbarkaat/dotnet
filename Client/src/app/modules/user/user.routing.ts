import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { UserSignupComponent } from "./user-signup/user-signup.component";

import { UserManagerComponent } from "./user-manager/user-manager.component";
import { AuthGuard } from "../core/guards/auth.guard";

const routes: Routes = [
    { path: '', component: UserManagerComponent, canActivate: [AuthGuard] }, 
    { path: 'signup', component: UserSignupComponent }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UserRoutingModule { }