import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthorComponent } from "./author.component";

const authorRoutes:Routes= [{
    path: '',
    component: AuthorComponent
}];

@NgModule({
    imports:[RouterModule.forChild(authorRoutes)],
    exports:[RouterModule]
})
export class AuthorRoutingModule {}