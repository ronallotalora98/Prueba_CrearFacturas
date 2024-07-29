import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PagesModule } from './Pages/Pages.module';


const routes: Routes = [

  //{path: 'home', loadChildren:() => import('./pages/oxiyopal/oxiyopal.module').then(m => m.OxiyopalModule)},
  {path: 'home', loadChildren:() => import('./Pages/Pages.module').then(m => m.PagesModule)},
  //{path: 'auth', loadChildren:() => import('./auth/auth.module').then(m => m.AuthModule)},
  { path: '', redirectTo: 'home', pathMatch: 'full' },

];


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    PagesModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
