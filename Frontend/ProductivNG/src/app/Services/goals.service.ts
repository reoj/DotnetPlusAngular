import { Injectable } from '@angular/core';
import { Subscription } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Goal } from '../Models/Goal';

@Injectable({
  providedIn: 'root',
})
export class GoalsService {
  private goalsSubscription: Subscription = new Subscription();
  constructor(public httpClient: HttpClient) {}

  getGoals(): Goal[] {
    let goals: Goal[] = [];
    this.goalsSubscription = this.httpClient
      .get('http://localhost:3000/goals')
      .subscribe((data: any) => {
        data.forEach((goal: any) => {
          goals.push(
            new Goal(
              goal.id,
              goal.name,
              goal.description,
              new Date(goal.dueDate),
              goal.isComplete,
              goal.progressPercentage
            )
          );
        });
      });
    return goals;
  }
}
