import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { UserSignupComponent } from "./user-signup/user-signup.component";

import { UserManagerComponent } from "./user-manager/user-manager.component";

const routes: Routes = [{
    path: 'user',
    component: UserManagerComponent,
    children: [
        { path: 'signup', component: UserSignupComponent }
    ]

}];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UserRoutingModule { }