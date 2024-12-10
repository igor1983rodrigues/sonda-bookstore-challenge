import { NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { BookRoutingModule } from './book-routing.module';
import { BookComponent } from './book.component';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BookRoutingModule
  ]
})
export class BookModule { }
