import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FullLayoutComponent } from './layout/full-layout/full-layout.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { ContentLayoutComponent } from './layout/content/content.component';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";

import {
  PerfectScrollbarModule,
  PERFECT_SCROLLBAR_CONFIG,
  PerfectScrollbarConfigInterface
} from 'ngx-perfect-scrollbar';
import { ToastrModule } from "ngx-toastr";
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './content-pages/login/login.component';
import { ErrorComponent } from './content-pages/error/error.component';
import { SharedModule } from './shared/shared.module';
import { AuthenticationService } from './core/auth/auth.service';
import { JwtInterceptor } from './core/_helpers/jwt.interceptor';
import { ErrorInterceptor } from './core/_helpers/error.interceptor';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelPropagation: false
};

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, "./assets/i18n/", ".json");
}

@NgModule({
  declarations: [
    AppComponent, FullLayoutComponent, ContentLayoutComponent
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    ToastrModule.forRoot(),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient]
      }
    }),
    PerfectScrollbarModule
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    },
    { provide: PERFECT_SCROLLBAR_CONFIG, useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
