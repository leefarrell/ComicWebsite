import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ComicListComponent } from './comic-list/comic-list.component';
import { ComicDetailsComponent } from './comic-details/comic-details.component';
import { MessagesComponent } from './messages/messages.component';
import { ListComponent } from './list/list.component';
import { AuthGuard } from './_guards/auth.guard';
import { EditUserComponent } from './edit-user/edit-user.component';
import { RegisterComponent } from './register/register.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'comics/:id', component: ComicDetailsComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'comics', component: ComicListComponent},
            {path: 'user/edit', component: EditUserComponent},
            {path: 'messages', component: MessagesComponent},
            {path: 'list', component: ListComponent},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},
];

