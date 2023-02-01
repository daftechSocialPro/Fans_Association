import {useRef }from 'react'
import { BrowserRouter, Route,Routes } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './pages/Home';
import News from './pages/News';
import NewsDetails from './pages/NewsDetails';
import Mahber from './pages/Mahber';
import Tmret from './pages/Tmret';
import Statstics from './pages/Statstics';
import Table from './pages/Table';
import Match from './pages/Match'
import { urlHub } from './endpoints';
import {
  HubConnectionBuilder,
  LogLevel,
  HttpTransportType,
} from "@microsoft/signalr";

function App() {

  let connection = null;
  const connectionRef = useRef(connection);

  if (!connectionRef.current) {
    connection = new HubConnectionBuilder()
      .withUrl(urlHub, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
      })
      .configureLogging(LogLevel.Debug)
      .build();
    connection
      .start()
      .then(() => {
        console.log("Connection started.......!");
      })
      .catch((err) => console.log("Error while connect with server", err));

    connectionRef.current = connection;
  }

  return (

    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home connection={connection} />} />
        <Route path="newslist" element={<News /> }/>
        <Route path="news" element={<NewsDetails />} />
        <Route path='mahber' element={<Mahber/> }/> 
        <Route path='tmret' element={<Tmret/>} />
        <Route path='stat' element={<Statstics/>} />
        <Route path='tableview' element={<Table connection={connection}/>} />
        <Route path='match' element={<Match/>} />
      </Route>
     
    </Routes>
  </BrowserRouter>
  );
}

export default App;
