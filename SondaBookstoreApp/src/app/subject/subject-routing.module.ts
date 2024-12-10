import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SubjectComponent } from "./subject.component";

const bookRoutes: Routes = [{
    path: '',
    component: SubjectComponent,
    children:[]
}];

@NgModule({
    imports:[RouterModule.forChild(bookRoutes)],
    exports:[RouterModule]
})
export class SubjectRoutingModule {}