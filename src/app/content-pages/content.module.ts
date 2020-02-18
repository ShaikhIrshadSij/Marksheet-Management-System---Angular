import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { FormsModule } from '@angular/forms';
import { ErrorComponent } from './error/error.component';
import { LoginComponent } from './login/login.component';
import { ContentPagesRoutingModule } from './content-routing.module';

@NgModule({
    imports: [
        CommonModule,
        ContentPagesRoutingModule,
        FormsModule        
    ],
    declarations: [
        LoginComponent,
        ErrorComponent
    ]
})
export class ContentPagesModule { }
