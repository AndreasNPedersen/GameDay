import React, { useEffect, useState } from 'react';
import { FetchGetDeleteGroup, FetchGetGroupsAttendees, FetchPostJoinGroup, FetchPostLeaveGroup } from '../FetchHelper';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Squad from '../img/Squad.jpg'
import { Group, GroupAttendeen } from '../obj/Objects'
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import { useNavigate } from 'react-router';

export interface SimpleDialogProps {
  data: Group;

}
function GroupDialog(props: SimpleDialogProps) {
  const { data } = props;

  const [AttendeesData, setAttendeesData] = useState<GroupAttendeen[]>([]);
  const [open, setOpen] = React.useState(false);
  const [joined, setJoined] = React.useState<Boolean>();
  const navigate = useNavigate();

  const handleClickOpen = async () => {
    await groupList();
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const JoinnClose = () => {
    FetchPostJoinGroup(data.group.groupId, Number(sessionStorage.getItem("userId")));
    setOpen(false)
    //navigate("/login")
  }

  const Leave = () => {
    FetchPostLeaveGroup(data.group.groupId, Number(sessionStorage.getItem("userId")));
    setOpen(false)
    //navigate("/login")
  }

  const groupList = async () => {
    const fetchGroupAttendees = await FetchGetGroupsAttendees(data.group.groupId);
    const group = await fetchGroupAttendees.json().then((data) => data)
    setAttendeesData(group);
  }


  const dateFormat = (time: string) => {
    var date = new Date(time);
    return date.toLocaleString();
  }

  function Joined () {
    var a = false;
    for (var i = 0; i < AttendeesData.length; i++) {
      if (AttendeesData[i].userAttendeen.userId == Number(sessionStorage.getItem("userId"))) {
        console.log("yes joined")
        a = true;
      }
    }
    console.log("not joined")

    if (AttendeesData.length == data.group.maxPlayers) {
      return (<div>
        {Owned()}
        <p>Group is Made</p>
        <Button onClick={handleClose}>Close</Button>
      </div>
      )
    }
    if (!a) {
      return (<div>
        {Owned()}
        <Button onClick={JoinnClose} autoFocus>
          Join Group
        </Button>
        <Button onClick={handleClose}>Close</Button>
      </div>)
    } else {
      return (<div>
        {Owned()}
        <Button  onClick={Leave} autoFocus>
          Leave Group
        </Button>
        <Button onClick={handleClose}>Close</Button>
      </div>
      )
    }


  }

  function deleteGroup() {
    FetchGetDeleteGroup(data.group.groupId)
    setOpen(false)
    navigate("/login")
  }

  function Owned() {
    var a = data.userOwner.name;
    var b = sessionStorage.getItem("userName");
    var c = false
      if (a == b) {
        console.log("yes owned")
        c = true;
      }
    
    console.log("not owned")

    if (!a) {
      return (<div>
      </div>)
    } else {
      return <Button onClick={()=>deleteGroup()} autoFocus>
          Delete Group
        </Button>

    }
  }




  return (
    <div>
      <Button onClick={handleClickOpen}>
        View Details
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
      >
        <DialogTitle>
          Group: {data.group.name}
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            <Typography align='center'>
              <img src={Squad} style={{ borderRadius: "50%", height: "200px" }}></img>
            </Typography>
            <p>{data.group.description}</p>
            <p>Set on the date / time:<b>{dateFormat(data.group.date).toString()}</b> </p>
            <p>Group created by {data.userOwner.discordName} and with the steam name: {data.userOwner.steamName}</p>
            <p>Users needed in the Group: {data.group.maxPlayers}</p>
            <b>User Attendeens:</b>
            <div>
              {AttendeesData.map((data, index) => (
                <p><b>{index+1}: </b>Username: {data.userAttendeen.name} with Steam name: {data.userAttendeen.steamName} and Discord name: {data.userAttendeen.discordName}</p>
              ))}
            </div>
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <div>
            {Joined()}
          </div>
        </DialogActions>
      </Dialog>
    </div>
  )
}

export default GroupDialog;
