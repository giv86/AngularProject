import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { GameComponent } from './game/game.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';
import { AdminSettingsComponent } from './admin-settings/admin-settings.component';
import { NavigationComponent } from './navigation/navigation.component';
import { AdminLocationsComponent } from './admin-locations/admin-locations.component';
import { AdminConversationsComponent } from './admin-conversations/admin-conversations.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { UserHeroesComponent } from './user-heroes/user-heroes.component';
import { AppRoutingModule } from './app-routing.module';
import { State } from './state.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    GameComponent,
    UserSettingsComponent,
    AdminSettingsComponent,
    NavigationComponent, // dodajemy NavigationComponent
    AdminLocationsComponent,
    AdminConversationsComponent,
    AdminUsersComponent,
    UserHeroesComponent,
    AppComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([], { useHash: true }),
  ],
  providers: [State],
  bootstrap: [AppComponent]
})
export class AppModule { }
