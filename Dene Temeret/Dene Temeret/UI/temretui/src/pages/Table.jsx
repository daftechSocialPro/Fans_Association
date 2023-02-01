import React, {  useEffect, useState } from "react";
import axios from "axios";
import dateformat from 'dateformat'
import moment from "moment";
import { assetUrl, urlMatch, urlTeam } from "../endpoints";
function Table({connection}) {
  const [table, setTable] = useState([]);
 const [score,setScore]= useState([])
  const [match, setMatch] = useState([]);
  useEffect(() => {
    axios.get(`${urlMatch}`).then((res) => {
      setMatch(res.data);
    });


  }, []);
  useEffect(() => {
    axios.get(`${urlMatch}/score`).then((res) => {
      setScore(res.data);
    });
  }, []);

  useEffect(() => {
    axios.get(`${urlTeam}/getAllTable`).then((res) => setTable(res.data));
  }, []);


  if (connection) {
    connection.on("getNews", (result) => {
      setTable(result.team);
      setScore(result.matches)    
    });
  }
 

  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  return (
    <>
      <header className="pageHero tabbedHero ">
        <div className="wrapper col-12">
          <h1 className="pageTitle">ፕሪሚየር ሊግ ደረጃ ሰንጠረዥ</h1>
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

     
    

      <div className="allTablesContainer">
        <div className="wrapper col-12">
          <div className="tableContainer">
            <div className="table wrapper col-12">
              <summary className="visuallyHidden">
                This table charts the Premier League teams
              </summary>
              <table>
                <thead>
                  <tr>
                    <th class="text-centre" scope="col">
                      <div class="thFull">ደረጃ</div>
                      <div class="thShort">ደ</div>
                    </th>
                    <th class="team" scope="col">
                      ክለብ
                    </th>
                    <th scope="col">
                      <div class="thFull">ጨዋታ</div>
                      <div class="thShort">ጨ</div>
                    </th>
                    <th scope="col">
                      <div class="thFull">ማሸነፍ</div>
                      <div class="thShort">ማ</div>
                    </th>
                    <th scope="col">
                      <div class="thFull">አቻ</div>
                      <div class="thShort">አ</div>
                    </th>
                    <th scope="col">
                      <div class="thFull">ሽንፈት</div>
                      <div class="thShort">ሽ</div>
                    </th>
                    <th class="hideSmall" scope="col">
                      <abbr title="Goals For">ያገባው</abbr>
                    </th>
                    <th class="hideSmall" scope="col">
                      <abbr title="Goals Against">የገባበት</abbr>
                    </th>
                    <th scope="col">
                      <abbr title="Goal Difference">ግብ ልዪነት</abbr>
                    </th>
                    <th scope="col" class="points">
                      <div class="thFull">ነጥብ</div>
                      <div class="thShort">ነ</div>
                    </th>
                    <th class="teamForm hideMed" scope="col">
                      አቋም
                    </th>

                    <th class="hideMed text-centre" scope="col">
                      ቀጣይ
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {table.map((item, index) => (
                    <tr
                      class="tableDark"
                      key={index}
                      data-compseason="489"
                      data-filtered-entry-size="20"
                      data-filtered-table-row="1"
                      data-filtered-table-row-name="Arsenal"
                      data-filtered-table-row-opta="t3"
                      data-position="1"
                      data-filtered-table-row-abbr="1"
                    >
                      <td class="pos button-tooltip" tabindex="0" id="Tooltip">
                        <span class="value">{index + 1}</span>
                      </td>
                      <td class="team" scope="row">
                        <a >
                          <span
                            class="badge badge-image-container"
                            data-widget="club-badge-image"
                            data-size="25"
                          >
                            <img
                              class="badge-image badge-image--25"
                              src={getImage(item.logo)}
                            />
                          </span>
                          <span class="long">{item.name}</span>
                          <span class="short">{item.shortName}</span>
                        </a>
                      </td>
                      <td>{item.mp}</td>
                      <td>{item.win}</td>
                      <td>{item.draw}</td>
                      <td>{item.lost}</td>
                      <td class="hideSmall">{item.gf}</td>
                      <td class="hideSmall">{item.ga}</td>
                      <td>
                        {item.gd > 0 && "+"}{item.gd}
                      </td>
                      <td class="points">{item.pts}</td>
                      <td class="form hideMed">

                        {match.filter(x=>(x.team1Id===item.id||x.team2Id===item.id) && x.game!=0).slice(0,5).map((ma,index)=>

                        <li key={index}
                          tabindex="0"
                          class=  {(ma.team1Id===item.id && ma.team1Score>ma.team2Score||ma.team2Id===item.id && ma.team1Score<ma.team2Score )? "win button-tooltip":(ma.team1Id===item.id && ma.team1Score<ma.team2Score||ma.team2Id===item.id && ma.team1Score>ma.team2Score )?"lose button-tooltip":"button-tooltip"}   
                          id="Tooltip"
                          style={{marginLeft:'5px'}}
                        >
                          <abbr title="Lost" class="form-abbreviation">
                             {(ma.team1Id===item.id && ma.team1Score>ma.team2Score||ma.team2Id===item.id && ma.team1Score<ma.team2Score )? "W":(ma.team1Id===item.id && ma.team1Score<ma.team2Score||ma.team2Id===item.id && ma.team1Score>ma.team2Score )?"L":"D"}   
                          </abbr>
                          <a
                        
                            class="tooltipContainer linkable tooltip-link tooltip-right"
                            role="tooltip"
                          >
                            <span class="tooltip-content">
                              <div class="matchAbridged">
                                <span class="matchInfo">
                                  {dateformat(ma.matchDate)}
                                </span>
                                <span class="teamName">
                                  <abbr title={ma.team2.name}>{ma.team1.shortName}</abbr>
                                </span>
                                <span
                                  class="badge badge-image-container"
                                  data-widget="club-badge-image"
                                  data-size="20"
                                >
                                  <img
                                    class="badge-image badge-image--20"
                                    src={getImage(ma.team1.logo)}
                                    
                                  />
                                </span>
                                <span class="score">
                                  {ma.team1Score} <span>-</span>{ma.team2Score}
                                </span>
                                <span
                                  class="badge badge-image-container"
                                  data-widget="club-badge-image"
                                  data-size="20"
                                >
                                  <img
                                    class="badge-image badge-image--20"
                                    src={getImage(ma.team2.logo)}
                                  />
                                </span>
                                <span class="teamName">
                                  <abbr title={ma.team2.name}>{ma.team2.shortName}</abbr>
                                </span>
                              
                              </div>
                            </span>
                          </a>
                        </li> 
                           )}                   
                      </td>

                      <td class="nextMatchCol hideMed">
                      {score.filter(x=>x.team1Id===item.id||x.team2Id===item.id).slice(0,5).map((ma,index)=>
                        <span tabindex="0" key={index} class="button-tooltip" id="Tooltip">
                          <span class="nextMatch">
                            <span
                              class="badge badge-image-container"
                              data-widget="club-badge-image"
                              data-size="20"
                            >
                              <img
                                class="badge-image badge-image--20"
                                src={ma.team1Id===item.id?getImage(ma.team2.logo):getImage(ma.team1.logo)}
                               
                              />
                              <span class="visuallyHidden">
                              {ma.team1Id===item.id?ma.team2.name:ma.team1.name}
                              </span>
                            </span>
                          </span>
                          <a
                            
                            class="tooltipContainer linkable tooltip-link tooltip-right"
                            role="tooltip"
                          >
                            <span class="tooltip-content">
                              <div class="matchAbridged">
                                <span class="matchInfo">
                                  {dateformat(ma.machDate)}
                                </span>
                                <span class="teamName">
                                  <abbr title="Arsenal">{ma.team1.shortName}</abbr>
                                </span>
                                <span
                                  class="badge badge-image-container"
                                  data-widget="club-badge-image"
                                  data-size="20"
                                >
                                  <img
                                    class="badge-image badge-image--20"
                                    src={getImage(ma.team1.logo)}
                                   
                                  />
                                </span>
                                <time>
                                {ma.game === 0
                ? moment(ma.matchDate).format("HH:MM A")
                : `${ma.team1Score} - ${ma.team2Score}`}
              <br /> {ma.game === 2 && "FT"}{" "}
           
                                </time>
                                <span
                                  class="badge badge-image-container"
                                  data-widget="club-badge-image"
                                  data-size="20"
                                >
                                  <img
                                    class="badge-image badge-image--20"
                                    src={getImage(ma.team2.logo)}
                                  
                                  />
                                </span>
                                <span class="teamName">
                                  <abbr title="Tottenham Hotspur">{ma.team2.shortName}</abbr>
                                </span>
                            
                              </div>
                            </span>
                          </a>
                        </span>)}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Table;
