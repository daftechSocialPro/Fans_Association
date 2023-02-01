import React, { useState, useEffect } from "react";
import { assetUrl, urlMatch, urlPlayer } from "../endpoints";
import axios from "axios";
import moment from "moment";
import {GiSoccerBall,GiRunningShoe} from  'react-icons/gi'

function Match() {
  const [match, setMatch] = useState([]);
  const [players, setPlayers] = useState([]);
  const [maa , setMaa]= useState(null)


  useEffect(() => {
    axios.get(`${urlMatch}/score`).then((res) => {
      console.log(res.data);
      setMatch(res.data);
    });
  }, []);
  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  const getPlayers = (playerId) => {
    axios
      .get(`${urlPlayer}/getPlayerName/?playerId=${playerId}`)
      .then((res) => {
        setPlayers((prev) => [...prev, { id: playerId, name: res.data }]);
      });
  };

  return (
    <>
      <header className="pageHero tabbedHero ">
        <div className="wrapper Col-12">
          <h1 className="pageTitle">ፕሪሚየር ሊግ ጨዋታዎች</h1>
          <div
            data-script="pl_tabbed"
            data-widget="tabbed-content"
            className="tabLinks left"
            data-tab-wrap=".tabs"
            data-tab-class="mainTableTab"
            data-update-tab-param="true"
          >
            <div className="tabs">
              <ul className="tablist" role="tablist">
                <li
                  role="tab"
                  tabIndex="0"
                  data-tab-index="0"
                  className="active"
                >
                  ፕሪሚየር ሊግ
                </li>
              </ul>
            </div>
          </div>
        </div>
      </header>
      <div className="wrapper col-12">
        <div className="col-6">
          <div className="fixturesAbridgedHeader ">
            <header>
              <div
                className="week"
                style={{ Color: "#110112", fontSize: "16px" }}
              >
                የጨዋታ ሳምንት {match[0] && match[0].matchWeek.matchWeek}
              </div>
              <div className="competition">
                <span
                  className="competitionLabel1"
                  style={{ fontSize: "16px" }}
                >
                  ፕሪሚየር ሊግ
                </span>
              </div>
              <div
                className="headerLocalTimeContainer"
                style={{ fontSize: "14px" }}
              >
                የሚታዩት ሁሉም ጊዜያት
                <span className="localTimeMessage--bold"> በአካባቢዎ ሰዓት</span>
              </div>
            </header>
          </div>

          <div
            className="embeddableMatchSummary clubSidebarWidget fixturesAbridgedContainer calendar"
            data-fixturesids="74991,74992,74993,74994,74997,74999,75000,74998,74995,74996"
            data-script="pl_club"
            data-widget="club-matches"
            data-pagesize="10"
          >
            <a
              className="ecal-sync-widget-button generateFixturesCalendar icon-button generateFixturesCalendar--sidebar"
              id="ecal-sync-widget-button"
              data-ecal-category="Fixture/{{ECAL_USER_COUNTRYCODE}}/Premier League,PL2 - Division 1,PL2 - Division 2,U18 Premier League - North,U18 Premier League - South"
              data-ecal-widget-id="5f2b97cce344056b0e8b456b"
              data-ecal-no-styling=""
            ></a>
            <div className="fixturesAbridged matchListContainer"></div>

            {match.map((item, index) => (
              <div key={index}>
                <a
                 
                  data-kickoff="1664623800000"
                  className="matchAbridged embeddableMatchContainer"
                  data-matchid="74991"
                  onClick={()=>setMaa(item)}
                  style={{borderRadius:'15px'}}
                >
                  <span className="teamName">
                    <abbr title={item.team1.name}>{item.team1.shortName}</abbr>
                  </span>
                  <span
                    className="badge badge-image-container"
                    data-widget="club-badge-image"
                    data-size="25"
                  >
                    <img
                      className="badge-image badge-image--25 js-badge-image"
                      src={getImage(item.team1.logo)}
                    />
                  </span>

                  <time
                    style={{ padding: "5px" }}
                    className="renderKOContainer"
                    data-kickoff="1664623800000"
                  >
                    {item.game === 0
                      ? moment(item.matchDate).format("DD-MM-YYYY")
                      : `${item.team1Score} - ${item.team2Score}`}
                    <br /> {item.game === 2 && "FT"}{" "}
                    {item.game === 0 &&
                      moment(item.matchDate).format("HH:MM A")}
                  </time>
                  <span
                    className="badge badge-image-container"
                    data-widget="club-badge-image"
                    data-size="25"
                  >
                    <img
                      className="badge-image badge-image--25 js-badge-image"
                      src={getImage(item.team2.logo)}
                    />
                  </span>
                  <span className="teamName">
                    <abbr title={item.team2.name}>{item.team2.shortName}</abbr>
                  </span>
                </a>

               
              </div>
            ))}
          </div>
        </div>
        <div className="col-6">
      

          <div
            className="embeddableMatchSummary clubSidebarWidget fixturesAbridgedContainer calendar"
            data-fixturesids="74991,74992,74993,74994,74997,74999,75000,74998,74995,74996"
            data-script="pl_club"
            data-widget="club-matches"
            data-pagesize="10"
          >
            <a
              className="ecal-sync-widget-button generateFixturesCalendar icon-button generateFixturesCalendar--sidebar"
              id="ecal-sync-widget-button"
              data-ecal-category="Fixture/{{ECAL_USER_COUNTRYCODE}}/Premier League,PL2 - Division 1,PL2 - Division 2,U18 Premier League - North,U18 Premier League - South"
              data-ecal-widget-id="5f2b97cce344056b0e8b456b"
              data-ecal-no-styling=""
            ></a>
            <div className="fixturesAbridged matchListContainer"></div>

           
          {maa &&    <div >
                <a
             
                  data-kickoff="1664623800000"
                  className="matchAbridged embeddableMatchContainer"
                  data-matchid="74991"
                  style={{borderRadius:'18px'}}
                >
                  <span className="teamName">
                    <abbr title= { maa.team1.name}>{maa.team1.shortName}</abbr>
                  </span>
                  <span
                    className="badge badge-image-container"
                    data-widget="club-badge-image"
                    data-size="25"
                  >
                    <img
                      className="badge-image badge-image--25 js-badge-image"
                      src={ getImage(maa.team1.logo)}
                    />
                  </span>

                  <time
                    style={{ padding: "5px" }}
                    className="renderKOContainer"
                    data-kickoff="1664623800000"
                  >
                    {maa.game === 0
                      ? moment(maa.matchDate).format("DD-MM-YYYY")
                      : `${maa.team1Score} - ${maa.team2Score}`}
                    <br /> {maa.game === 2 && "FT"}{" "}
                    {maa.game === 0 &&
                      moment(maa.matchDate).format("HH:MM A")}
                  </time>
                  <span
                    className="badge badge-image-container"
                    data-widget="club-badge-image"
                    data-size="25"
                  >
                    <img
                      className="badge-image badge-image--25 js-badge-image"
                      src={getImage(maa.team2.logo)}
                    />
                  </span>
                  <span className="teamName">
                    <abbr title={maa.team2.name}>{maa.team2.shortName}</abbr>
                  </span>
                </a>

               { maa.macthStats[0] &&       <a
                 
                  data-kickoff="1664623800000"
                className="matchAbridged"
                style={{border:'1px solid rgba(19, 2, 38, 0.11)',borderRadius:'15px'}}
                >

                  <table className="table  col-12">
                    <tr>
                    
                    </tr>
                    <tbody>
                      <tr>
                      <td>
                      <span
                    className="badge badge-image-container"
                    data-widget="club-badge-image"
                    data-size="25"
                  >
                    {maa.macthStats
                      .sort((a, b) => a.minute - b.minute||  a.playerDid - b.playerDid)
                      .filter((x) => x.teamId == maa.team1.id)
                      .map((ma, index) => (
                        <div key={index}>
                          <span
                            className="teamName"
                            style={ ma.playerDid == 1?{ fontSize: "10px" }: { fontSize: "12px" }}
                          >
                            <abbr>
                              {getPlayers(ma.playerId)}
                              {players.filter((x) => x.id == ma.playerId)[0] &&
                                players.filter((x) => x.id == ma.playerId)[0]
                                  .name}&nbsp;
                            </abbr>
                          </span>
                          <span>
                            {
                              <span style={{ fontSize: "20px" }}>&nbsp;
                                {ma.playerDid == 0 && <GiSoccerBall/>}
                                {ma.playerDid == 1 && <GiRunningShoe/>}
                                {ma.playerDid == 2 && (
                                  <img src="/assets/yellow.png" height={30} />
                                )}
                                {ma.playerDid == 3 && (
                                  <img src="/assets/red.png" height={30} />
                                )}{" "}
                                &nbsp;
                                {ma.minute}'
                              </span>
                            }
                          </span>

                          {   maa.macthStats[index+1] && maa.macthStats[index+1].minute != ma.minute  &&<hr/>}
                        </div>
                      ))}
                  </span>
                      </td>
                      <td>
                      <span
                    className="badge badge-image-container"
                    data-widget="club-badge-image"
                    data-size="25"
                  >
                    {maa.macthStats
                      .sort((a, b) => a.minute - b.minute ||  a.playerDid - b.playerDid)
                      .filter((x) => x.teamId == maa.team2.id)
                      .map((ma, index) => (
                        <div key={index}>
                          <span>
                            {
                              <span style={{ fontSize: "18px" }}>
                                {ma.playerDid == 0 && <GiSoccerBall/>}
                                {ma.playerDid == 1 && <GiRunningShoe/>}
                                {ma.playerDid == 2 && (
                                  <img src="/assets/yellow.png" height={30} />
                                )}
                                {ma.playerDid == 3 && (
                                  <img src="/assets/red.png" height={30} />
                                )}{" "}
                                &nbsp; 
                                {ma.minute}' &nbsp; 
                              </span>
                            }
                          </span>
                          <span
                            className="teamName"
                            style={{ fontSize: "10px" }}
                          >
                            <abbr>
                              {getPlayers(ma.playerId)}

                              {players.filter((x) => x.id == ma.playerId)[0] &&
                                players.filter((x) => x.id == ma.playerId)[0]
                                  .name}
                            </abbr>
                          </span>
                          {   maa.macthStats[index+1] && maa.macthStats[index+1].minute != ma.minute  &&<hr/>}
                        </div>
                      ))}
                  </span>
                      </td>
                      </tr>
                    
                    </tbody>
                  </table>




                &nbsp;
                 
                 
                </a>} 
              </div>
}
          </div>
        </div>
      </div>
    </>
  );
}

export default Match;
