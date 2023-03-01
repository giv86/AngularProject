import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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
import { IsLoggedGuard } from './is-logged.guard';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'game', component: GameComponent, canActivate: [IsLoggedGuard] },
  { path: 'user-settings', component: UserSettingsComponent, canActivate: [IsLoggedGuard] },
  { path: 'admin-settings', component: AdminSettingsComponent, canActivate: [IsLoggedGuard] },
  { path: 'navigation', component: NavigationComponent, canActivate: [IsLoggedGuard] },
  { path: 'admin-locations', component: AdminLocationsComponent, canActivate: [IsLoggedGuard] },
  { path: 'admin-conversations', component: AdminConversationsComponent, canActivate: [IsLoggedGuard] },
  { path: 'admin-users', component: AdminUsersComponent, canActivate: [IsLoggedGuard] },
  { path: 'user-heroes', component: UserHeroesComponent, canActivate: [IsLoggedGuard] },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
