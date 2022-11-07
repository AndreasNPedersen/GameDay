import React, { Dispatch, SetStateAction,useEffect, useState } from 'react';
import { FetchGetGames, FetchGetGroups, FetchPostCreateGroup } from '../FetchHelper';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { Group } from '../obj/Objects'
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import { MenuItem, TextField } from '@mui/material';

export interface SimpleDialogProps {
  dataG: Dispatch<SetStateAction<Group[]>>;

}

function GroupAddDialog(props:SimpleDialogProps) {
  const { dataG } = props;
  const [gameListInput, setGameListInput] = useState([{
    gameId: 0,
    name: ""
  }])
  
  const [gameInput, setGameInput] = useState({
    gameId: 0,
    name: ""
  })
  const [groupInput, setGroupInput] = useState(
    {
      groupId: 0,
      name: "",
      date: "0001-01-01T00:00:00",
      description: "",
      game: {
        gameId: 0,
        name: ""
      },
      maxPlayers: 0
    }
  )
  const [groupData, setGroupData] = useState(
    {
      id: 0,
      group: {
        groupId: 0,
        name: "",
        date: "0001-01-01T00:00:00",
        description: "",
        game: {
          gameId: 0,
          name: ""
        },
        maxPlayers: 0
      },
      userOwner: {
        userId: 0,
        name: "",
        password: "",
        discordName: "",
        steamName: "",
        created: "0001-01-01T00:00:00"
      }
    }
  )
  const [open, setOpen] = useState(false);
  const [responseStatusFail, setResponseStatusFail] = useState(false)
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
  async function inputSubmit() {
    console.log(gameInput)
    var data = groupInput;
    data.game.gameId = gameInput.gameId;
    setGroupInput(data)
    console.log(groupInput)
    if (groupInput.date.length!=16 || groupInput.description.length<=0 || groupInput.game.gameId <0 || groupInput.maxPlayers<0 || groupInput.name.length<=1 ) {
      setResponseStatusFail(true)
      return;
    }
   var data2 = groupData;
   data2.group = groupInput;
   data2.userOwner.userId = Number(sessionStorage.getItem("userId"));
   console.log(data2);
    const status = await FetchPostCreateGroup(data2);
    console.log(status.status);
    if (await status.status != 200) {
      setResponseStatusFail(true)
    } else {
      const fetchGroups = await FetchGetGroups();
      const group = await fetchGroups.json().then((data) => data)
      dataG(group);
      setOpen(false)
    }

  }

  useEffect(() => {
    const gamesList = async () => {
      const fetchGroups = await FetchGetGames();
      const games = await fetchGroups.json().then((data) => data)
      setGameListInput(games);
    }
    gamesList();
  }, [])


  return (
    <div>
      <Button onClick={handleClickOpen} style={{marginRight:"1rem",color:"black", fontWeight:"bold"}}>
        Create New Group
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        fullWidth
      >
        <DialogTitle>
          Create new Group
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            <Typography align='center'>
              {responseStatusFail &&
                <div style={{ color: "red" }}>Wrong Group inputs</div>
              }
              <label style={{ fontFamily: "KungFuMasterSpaced" }}>Group name:</label>
              <br />
              <TextField type={"text"} onChange={e => { setGroupInput({ ...groupInput, name: e.target.value }) }} id="outlined-basic" label="Group Name" variant="outlined" style={{ marginBottom: "10px", width: "500px" }} />
              <br />
              <label style={{ fontFamily: "KungFuMasterSpaced" }}>Group Description:</label>
              <br />
              <TextField multiline={true} maxRows={9} type={"text"} onChange={e => { setGroupInput({ ...groupInput, description: e.target.value }) }} id="outlined-basic" label="Description" variant="outlined" style={{ marginBottom: "10px", width: "500px" }} />
              <br />
              <label style={{ fontFamily: "KungFuMasterSpaced" }}>Group Game:</label>
              <br />
              <br />
              <TextField
                select
                style={{ marginBottom: "10px", width: "300px" }}
                label="Select the Game"
                value={gameInput.gameId}
                onChange={e => { setGameInput({ ...gameInput, gameId: parseInt(e.target.value) }) }}
                helperText="Please select the Game"
              >
                {gameListInput.map((option) => (
                  <MenuItem value={option.gameId}>
                    {option.name}
                  </MenuItem>
                ))}
              </TextField>
              <br />
              <label style={{ fontFamily: "KungFuMasterSpaced" }}>Max Group Attendees:</label>
              <br />
              <TextField type={"number"} onChange={e => { setGroupInput({ ...groupInput, maxPlayers: parseInt(e.target.value) }) }} id="outlined-basic" label="Max Players" variant="outlined" style={{ marginBottom: "10px", width: "300px" }} />
              <br />
              <label style={{ fontFamily: "KungFuMasterSpaced" }}>Group Appointment:</label>
              <br />
              <TextField
                type="datetime-local"
                sx={{ width: 250 }}
                InputLabelProps={{
                  shrink: true,
                }}
                style={{ marginBottom: "10px", width: "300px" }}
                onChange={e => { setGroupInput({ ...groupInput, date: e.target.value}) }}
                helperText="Please Select the date and input the time"
              />
              <br />
            </Typography>
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>Close</Button>
          <Button variant="contained" color="success" onClick={() => inputSubmit()} style={{ margin: "1rem" }}>Make Group</Button>
        </DialogActions>
      </Dialog>
    </div>
  )
}

export default GroupAddDialog;
