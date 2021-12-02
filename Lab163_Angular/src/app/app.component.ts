import { Component } from '@angular/core';
import { ITodo } from './todo';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title:string = 'Lab163-Angular';
  nameModel:string = "";
  filterTasksString:string = "";
  editTaskString:string = "";

  task1:ITodo = {task: 'fold clothes', completed: false};
  task2:ITodo = {task: 'put clothes in dresser', completed: false};
  task3:ITodo = {task: 'relax', completed: false};
  task4:ITodo = {task: 'try to pet cat', completed: true};
  task5:ITodo = {task: 'pet dog', completed: false};
  task6:ITodo = {task: 'be awesome', completed: false};

  tasks:ITodo[] = [this.task1, this.task2, this.task3, this.task4, this.task5, this.task6];

  completeTask = function (ev:Event, task:ITodo){
    task.completed = true;
  }

  editTask = function (ev:Event, task:ITodo){
    task.task = this.editTaskString;
    this.editTaskString = "";
  }

  addTask = function (){
    let task:ITodo = {task: this.nameModel, completed: false};
    this.tasks.push(task)
    this.nameModel = '';
  }

  removeTask = function (ev:Event, task:ITodo){
    let idx = this.tasks.indexOf(task);
    this.tasks.splice(idx, 1)
  }

  allTasksNotCompleted = function (){
    for (var val of this.tasks) {
      if (!val.completed) {
        return true;
      }
    }
  }

  filterTasks = function (task:ITodo){
    if (task.task.includes(this.filterTasksString)) {
        return false;
      }
      return true;
    }

}