import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { ContentListComponent } from './components/content-list/content-list.component';
import { ContactComponent } from './components/contact/contact.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  {
    path:"about",
    component: AboutComponent
  },
  {
    path:"contact",
    component: ContactComponent
  },
  {
    path:"contents",
    component:ContentListComponent

  },
  {
    path:"login",
    component: LoginComponent
  },
  {
    path:"register",
    component: RegisterComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
