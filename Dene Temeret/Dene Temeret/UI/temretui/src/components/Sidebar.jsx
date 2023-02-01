import React, { useEffect, useState, useRef } from "react";
import axios from "axios";
import { assetUrl, urlAdvert, urlDashboard, urlHub, urlMatch, urlPlayer, urlTeam } from "../endpoints";
import moment from "moment";
import { useNavigate } from "react-router-dom";
import Flag from 'react-world-flags'

function Sidebar({connection}) {
  const [standings, setTables] = useState([]);
  const [match, setMatch] = useState([]);
  const [goal, setGoal] = useState([]);
  const [assist, setAssist] = useState([]);
  const navigate = useNavigate();
  const [advert,setAdvert]=useState([]);
  useEffect(() => {
    axios
      .get(`${urlDashboard}/table`)
      .then((res) => {
        setTable(res.data.slice(0,4));
        //"user Table", table);
      })
      .catch((err) => console.error(err));
  }, []);

  const [table, setTable] = useState([]);
  
  useEffect(() => {
    getMatch()
    axios.get(`${urlAdvert}`).
    then((res) => {
      setAdvert(res.data.filter(x=>x.postition==0))
    }).catch((err)=>console.error(err));
  }, []);
  

  const getMatch =()=>{
    axios.get(`${urlMatch}/score`).
    then((res) => {
      setMatch(res.data);
    }).catch((err)=>console.error(err));
  }


  useEffect(() => {
    getTeam();


  }, []);

  if (connection) {
    connection.on("getMatch", (result) => {
      
      setMatch(result);
    });

    connection.on("getTeams", (result) => {

      console.log("res",result)
       setMatch(result.matches)
      setTables(result.team);
      var d = [...result.goalViews];
      setAssist(result.goalViews.sort((a, b) => b.assist - a.assist));
      setGoal(d.sort((a, b) => b.goals - a.goals));
    });
  }

  useEffect(() => {
    axios
      .get(`${urlPlayer}/getStat`)
      .then((res) => {
        var d = [...res.data];
        setAssist(res.data.sort((a, b) => b.assist - a.assist));
        setGoal(d.sort((a, b) => b.goals - a.goals));
      })
      .catch((err) => console.error(err));
  }, []);

  const getTeam = () => {
    axios.get(`${urlTeam}/getAllTable`).then((res) => setTables(res.data));
  };
  //"matches", match);
  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  const goToTable = (url) => {
    navigate(url);
  };
  return (
    <nav className="fixedSidebar">
      <h1 className="visuallyHidden" style={{ fontSize: "18px" }}>
        ፕሪሚየር ሊግ
      </h1>

      
      <div
        data-script="pl_tabbed"
        data-widget="tabbed-content"
        className="tabbedContent homeStandingsHeader text-center"
        data-tab-wrap=".tabs"
        data-tab-param="tables"
      >
        {/* <span className="icn pl-logo-centered-w-sm"></span> */}
        <span
          style={{
            color: "white",
            fontSize: "18px",
            display: "table",
            margin: "0 auto",
          }}
        >
          የተመዘገቡ ደጋፊወች ብዛት
        </span>

        <div className="tabs"></div>
      </div>

      <div className="" data-ui-tab="First Team">
        <div
          data-widget="match-week-table"
          data-script="pl_match-week"
          data-compseason="489"
          data-competition="1"
          data-live="true"
        >
          <div className="tablesContainer">
            <div className="table tableSmall homeStandings js-standings-entry-container">
              <div className="liveLeague toggle-btn js-live-toggle-container is-active u-hide">
                <div className="live-animation">
                  <span></span>
                </div>
                <span>
                  <span className="liveLeague__live"> Live</span> League Table
                </span>
              </div>
              <summary className="visuallyHidden">
                This abridged table charts the Premier League teams
              </summary>
              <table>
                <thead>
                  <tr>
                    <th scope="col">
                      <abbr title="Position">ደረጃ</abbr>
                    </th>
                    <th className="team" scope="col">
                      ክለብ
                    </th>
                    <th scope="col">
                      <abbr title="Played">ደጋፊ ብዛት</abbr>
                    </th>
                  
                  </tr>
                </thead>

                <tbody className="standingEntriesContainer isPL">
                  {table.map((item, index) => (
                    <tr
                      key={index}
                      className="tableDark"
                      data-filtered-table-row="1"
                      data-filtered-table-row-name="Arsenal"
                      data-position="1"
                      data-filtered-table-row-abbr="1"
                    >
                      <td className="pos">
                        <span className="value">{index + 1} </span>
                        {/* <span className="movement  none "><span className="visuallyHidden">የቀድሞ አቀማመጥ </span></span>
                         */}
                      </td>
                      <td className="team" scope="row">
                        <a>
                          <span
                            className="badge badge-image-container"
                            data-widget="club-badge-image"
                            data-size="20"
                          >
                            <img
                              className="badge-image badge-image--20 js-badge-image"
                              src={getImage(item.image)}
                            />
                          </span>
                          {item.mahberName}
                        </a>
                      </td>
                      <td>{item.numberOfDegafi}</td>

                    
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <a class="btn widget-button" onClick={() => goToTable("stat")}>
              ሁሉንም ደረጃ ሰንተረዥ ተመልከት<span class="icn arrow-right"></span>
            </a>
          </div>
        </div>
      </div>
      <div style={{ marginBottom: "20px" }}>
      {advert[0] && <img style={{ width: "100%" }} src={getImage(advert[0]&&advert[0].adPhoto)} /> }
      </div>

      <div className="fixturesAbridgedHeader ">
        <header>
          <div className="week" style={{ color: "#110112", fontSize: "16px" }}>
            የጨዋታ ሳምንት {match[0] && match[0].matchWeek.matchWeek}
          </div>
          <div className="competition">
            <span className="competitionLabel1" style={{ fontSize: "16px" }}>
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
          <a
            key={index}
            data-kickoff="1664623800000"
            className="matchAbridged embeddableMatchContainer"
            data-matchid="74991"
          >
            <span className="teamName">
              <abbr title="Arsenal">{item.team1.shortName}</abbr>
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
              {item.game === 0 && moment(item.matchDate).format("HH:MM A")}
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
              <abbr title="Tottenham Hotspur">{item.team2.shortName}</abbr>
            </span>
            <span className="icn arrow-right"></span>
            <div
              data-id="74991"
              data-comp="1"
              className="matchSummaryBroadcastersContainer"
            ></div>
          </a>
        ))}
        <a class="btn widget-button" onClick={() => goToTable("match")}>
          ሁሉንም ጨዋታ ተመልከት<span class="icn arrow-right"></span>
        </a>
      </div>

      <div style={{ marginBottom: "20px" }}>
      {advert[1] && <img style={{ width: "100%" }} src={getImage(advert[1]&&advert[1].adPhoto)} />}
      </div>

      <div
        data-script="pl_tabbed"
        data-widget="tabbed-content"
        className="tabbedContent homeStandingsHeader text-center"
        data-tab-wrap=".tabs"
        data-tab-param="tables"
      >
        {/* <span className="icn pl-logo-centered-w-sm"></span> */}
        <span
          style={{
            color: "white",
            fontSize: "18px",
            display: "table",
            margin: "0 auto",
          }}
        >
          ደረጃ ሰንጠረዥ
        </span>

        <div className="tabs"></div>
      </div>

      <div className="" data-ui-tab="First Team">
        <div
          data-widget="match-week-table"
          data-script="pl_match-week"
          data-compseason="489"
          data-competition="1"
          data-live="true"
        >
          <div className="tablesContainer">
            <div className="table tableSmall homeStandings js-standings-entry-container">
              <div className="liveLeague toggle-btn js-live-toggle-container is-active u-hide">
                <div className="live-animation">
                  <span></span>
                </div>
                <span>
                  <span className="liveLeague__live"> Live</span> League Table
                </span>
              </div>
              <summary className="visuallyHidden">
                This abridged table charts the Premier League teams
              </summary>
              <table>
                <thead>
                  <tr>
                    <th scope="col">
                      <abbr title="Position">ደረጃ</abbr>
                    </th>
                    <th className="team" scope="col">
                      ክለብ
                    </th>
                    <th scope="col">
                      <abbr title="Played">ጨ</abbr>
                    </th>
                    <th scope="col">
                      <abbr title="Goal Difference">ግብ ልዩ</abbr>
                    </th>
                    <th scope="col">
                      <abbr title="Points">ነጥብ</abbr>
                    </th>
                  </tr>
                </thead>

                <tbody className="standingEntriesContainer isPL">
                  {standings.map((item, index) => (
                    <tr
                      key={index}
                      className="tableDark"
                      data-filtered-table-row="1"
                      data-filtered-table-row-name="Arsenal"
                      data-position="1"
                      data-filtered-table-row-abbr="1"
                    >
                      <td className="pos">
                        <span className="value">{index + 1} </span>
                        {/* <span className="movement  none "><span className="visuallyHidden">የቀድሞ አቀማመጥ </span></span>
                         */}
                      </td>
                      <td className="team" scope="row">
                        <a>
                          <span
                            className="badge badge-image-container"
                            data-widget="club-badge-image"
                            data-size="20"
                          >
                            <img
                              className="badge-image badge-image--20 js-badge-image"
                              src={getImage(item.logo)}
                            />
                          </span>
                          {item.name}
                        </a>
                      </td>
                      <td>{item.mp}</td>

                      <td>{item.gd}</td>
                      <td className="points">{item.pts}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <a class="btn widget-button" onClick={() => goToTable("tableview")}>
              ሁሉንም ደረጃ ሰንተረዥ ተመልከት<span class="icn arrow-right"></span>
            </a>
          </div>
        </div>
      </div>


      

      {goal[0] && goal[0].goals > 0 && (
        <div
          style={{ marginTop: "20px", border: "solid 1px #65502047" }}
          className="statsCard"
          data-widget="featured-player"
          data-player-id="21737"
          data-template="featuredplayerclub"
          data-script="pl_player"
        >
          <header>
            <h4 className="statsTitle">ኮክብ ግል</h4>
            <div
              data-script="pl_social-share"
              data-widget="social-page-share"
              data-render="statsshare"
              data-link-to="/players/21737/Alexander-Isak/overview"
            ></div>
          </header>
          <ul className="statsList">
            <li className="statsHero active ">
              <a
                className="statName"
                href="players/21737/Alexander-Isak/overview.html"
              >
                {goal[0] && goal[0].name}
              </a>

              <div className="position">{goal[0] && goal[0].position}</div>

              <div className="pos">
              <span className="flag ETH">
                <Flag code="eth" height="16" />
                </span>
                <span className="playerCountry">
                  {goal[0] && goal[0].nationality}
                </span>
              </div>

              <div className="imgCropContainer">
                <img
                  data-script="pl_player-image"
                  data-widget="player-image"
                  data-player="p219168"
                  data-size="110x140"
                  className="statCardImg statCardPlayer"
                  src={getImage(goal[0] && goal[0].userPhoto)}
                  alt={goal[0] && goal[0].name}
                />
              </div>

              <div className="js-player-comp-season statSeason"></div>
            </li>

            <li className="statsRow">
              <div className="pos">Club</div>
              <div className="stat js-player-club">
                {goal[0] && goal[0].club}

                <span
                  className="badge badge-image-container"
                  data-widget="club-badge-image"
                  data-size="20"
                >
                  <img
                    className="badge-image badge-image--20 js-badge-image"
                    src={getImage(goal[0] && goal[0].clubLogo)}
                    alt={goal[0] && goal[0].club}
                  />
                </span>
              </div>
            </li>

            <li className="statsRow">
              <div className="pos">Goals</div>
              <div className="stat">{goal[0] && goal[0].goals}</div>
            </li>
            <li className="statsRow">
              <div className="pos">Assists</div>
              <div className="stat">{goal[0] && goal[0].assist}</div>
            </li>
          </ul>
        </div>
      )}

      {assist[0] && assist[0].assist > 0 && (
        <div
          style={{ marginTop: "20px", border: "solid 1px #65502047" }}
          className="statsCard"
          data-widget="featured-player"
          data-player-id="21737"
          data-template="featuredplayerclub"
          data-script="pl_player"
        >
          <header>
            <h4 className="statsTitle">ኮክብ ግብ አመቻች</h4>
            <div
              data-script="pl_social-share"
              data-widget="social-page-share"
              data-render="statsshare"
              data-link-to="/players/21737/Alexander-Isak/overview"
            ></div>
          </header>
          <ul className="statsList">
            <li className="statsHero active ">
              <a
                className="statName"
                href="players/21737/Alexander-Isak/overview.html"
              >
                {assist[0] && assist[0].name}
              </a>

              <div className="position">{assist[0] && assist[0].position}</div>

              <div className="pos">
                <span className="flag ETH">
                <Flag code="eth" height="16" />
                </span>
                <span className="playerCountry">
                  {assist[0] && assist[0].nationality}
                </span>
              </div>

              <div className="imgCropContainer">
                <img
                  data-script="pl_player-image"
                  data-widget="player-image"
                  data-player="p219168"
                  data-size="110x140"
                  className="statCardImg statCardPlayer"
                  src={getImage(assist[0] && assist[0].userPhoto)}
                  alt={assist[0] && assist[0].name}
                />
              </div>

              <div className="js-player-comp-season statSeason"></div>
            </li>

            <li className="statsRow">
              <div className="pos">Club</div>
              <div className="stat js-player-club">
                {assist[0] && assist[0].club}

                <span
                  className="badge badge-image-container"
                  data-widget="club-badge-image"
                  data-size="20"
                >
                  <img
                    className="badge-image badge-image--20 js-badge-image"
                    src={getImage(assist[0] && assist[0].clubLogo)}
                    alt={assist[0] && assist[0].club}
                  />
                </span>
              </div>
            </li>

            <li className="statsRow">
              <div className="pos">Assists</div>
              <div className="stat">{assist[0] && assist[0].assist}</div>
            </li>
            <li className="statsRow">
              <div className="pos">Goals</div>
              <div className="stat">{assist[0] && assist[0].goals}</div>
            </li>
          </ul>
        </div>
      )}
    </nav>
  );
}

export default Sidebar;
