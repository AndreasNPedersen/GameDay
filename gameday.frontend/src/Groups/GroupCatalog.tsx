import React, { useEffect, useState } from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { FetchGetGroups } from '../FetchHelper';
import { CardActionArea, TextField } from '@mui/material';
import Squad from '../img/Squad.jpg'
import GroupObject from '../obj/Objects'
import GroupDialog from './GroupDialog';
import GroupAddDialog from './GroupAddDialog';
import Grid from '@mui/material/Grid';

function GroupCatalog() {

  const [groupData, setGroupsData] = useState<GroupObject[]>([]);

  const dateFormat = (time:string) =>{
    var date = new Date(time);
    return date.toLocaleString();
  }
function makeGroup(data:any){
  return <GroupDialog data={data}></GroupDialog>
}


  useEffect(() => {
    const groupList = async () => {
      const fetchGroups = await FetchGetGroups();
      const group = await fetchGroups.json().then((data) => data)
      setGroupsData(group);

      console.log(group);
      console.log(groupData);
    }
    groupList();
  }, [groupData.length])

  return (
    <div>
      <Typography fontSize={50} align="center" fontWeight={""} style={{ color: "red", fontFamily: "wasted" }}>GameDay</Typography>
      <Typography align='center'>
        <GroupAddDialog dataG={setGroupsData}></GroupAddDialog>
      </Typography>
      <hr />
      <Typography fontSize={40} style={{ color: "black", fontFamily: "KungFuMasterSpaced" }}>Groups</Typography>
      <br />
      <div>
        <Grid container spacing={3}>
          

          
        {groupData.map(data => (<Grid item xs={3}>
          <Card sx={{ maxWidth: 490 }}>
            <CardActionArea>
              <CardMedia
                component="img"
                height="140"
                image={Squad}
              />
              <CardContent>
                <Typography gutterBottom variant="h5">
                  {data.group.name}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  <p>Game: {data.group.game.name}</p>
                  <p>Group created by {data.userOwner.name}</p>
                  <p>Set on the date:<b>{dateFormat(data.group.date).toString()}</b> 
                    </p>
                </Typography>
              <CardActions>
              {makeGroup(data)}
              </CardActions>
              </CardContent>
            </CardActionArea>
          </Card>
          </Grid>
        ))}
        </Grid>
      </div>
    </div>
  );
}

export default GroupCatalog;
