import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GoalsComponent } from './Components/goals/goal.component';
import { HttpClientModule } from '@angular/common/http';
import { GoalsDisplayComponent } from './Components/goals-display/goals-display.component';

@NgModule({
  declarations: [
    AppComponent,
    GoalsComponent,
    GoalsDisplayComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
