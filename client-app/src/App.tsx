import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {                                        //quello che vediamo qui dentro sembra html ma in realta e' jsx, sarebbe javascript zuccherato e viene compilato in javascript
    const [activities, setActivities] = useState([])    //la prima e' la variabile dove salviamo lo stato del component, la seconda e' una funzione per impostare lo stato

    useEffect(()=>{
        axios.get('http://localhost:5000/api/activities').then(response =>{     //col then facciamo qualcosa quando abbiamo ricevuto i dati dal database
            console.log(response);
            setActivities(response.data)                                        //stiamo impostando ad activities con la funzione setActivities lo stato
        })
    }, [])                                              //mettiamo un array di dependencies per bloccare la chiamata infinita all'impostazione di stato

    return (                                            //tutto quello che e' in {} e' codice javascript, per dare uno style dobbiamo passarglielo come un oggetto, tra {{}}, es:  style={{color:'red'}}
        <div>
            <Header as='h2' icon='users' content='reactivities'/>
            <List>
            {activities.map((activity:any) =>(      //stiamo applicando una funzione ad ogni activity dentro l'array activities
                <List.Item key={activity.id}>
                    {activity.title}
                </List.Item>
            ))}
            </List>
                
            
        </div>
    );
}

export default App;
