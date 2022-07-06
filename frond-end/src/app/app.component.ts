import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  ngOnInit(): void {


    setTimeout(() => {
      this.peliculasEnCines  =[{
        titulo:"Spider-Man",
        fechaLanzamiento:new Date('2021-12-15'),
        precio: 175.37
      },{
        titulo:"Cars-4",
        fechaLanzamiento:new Date('2021-12-15'),
        precio: 230.00
      },{
        titulo:"Moana",
        fechaLanzamiento:new Date('2021-12-15'),
        precio: 120.23
      }]
    },500)
  }
  title = 'al valor que yo quiera';

  persona ={
    Nombre:"Juan",
    Puesto:'Desarrollador',
    FechaNacimiento:new Date(),
    Salario: 2450.35
  }

  peliculasEnCines ;
  peliculasProximosEstrenos=[{
    titulo:"Encanto",
    fechaLanzamiento:new Date('2021-12-24'),
    precio: 189.23
  },{
    titulo:"Trax Matrix",
    fechaLanzamiento:new Date('2022-01-04'),
    precio: 200
  }];


  duplicarNumero(valor: number):number{
    return valor*2

  }
}
