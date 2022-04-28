import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';

import { UserManagerComponent } from "./user-manager/user-manager.component";

const routes: Routes = [{
    path: 'user',
    component: UserManagerComponent,
    /*
    children: [
        {path: '', component: componentName}
    ]
    */
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UserRoutingModule {}