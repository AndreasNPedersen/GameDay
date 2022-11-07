import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import Paper from '@mui/material/Paper';
import Container from '@mui/material/Container';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import "../fonts/Wasted.ttf";
import "../fonts/KungFuMasterSpaced.otf"
import "../fonts/KungFuMasterTwotoneItalic.otf"
import { Button } from '@mui/material';
import { FetchPostCreate } from "../FetchHelper";
import { useNavigate } from 'react-router-dom';


function LoginSignUp() {

    const [user, setUser] = useState({
        name: "",
        password: "",
        discordname:"",
        steamname:"",
        created:"2022-10-14T13:22:03.129Z"
    });
    const [responseStatusFail, setResponseStatusFail] = useState(false)
    const navigate = useNavigate();
    async function inputSubmit() {
        if (user.name.length<1 || user.password.length<1) {
            return;
        }
        const status = await FetchPostCreate(user);
        console.log(status.status);
        if (await status.status != 200) {
           setResponseStatusFail(true) 
        } else {
            navigate("/Login");
        }
        
    }


    return (
        <div>
            <div style={{ paddingTop: "1rem", textAlign: "center" }}></div>
            <Container>

                    <div>
                        <Typography fontSize={90} align="center" fontWeight={""} style={{ color: "red", fontFamily: "wasted" }}>GameDay</Typography>
                        <Grid container>
                            <Grid item xs={3}>

                            </Grid>
                            <Grid item xs={6}>
                                <Paper>
                                    <Typography align="center">
                                        <Typography fontSize={30} align="center" style={{ padding: "1rem", fontFamily: "KungFuMasterSpaced", fontWeight: "bold" }}>Create a new user</Typography>
                                        {responseStatusFail &&
                                            <div style={{color:"red"}}>Wrong User credentials or User name already taken</div>
                                        }
                                        <label style={{ fontFamily: "KungFuMasterSpaced" }}>UserName:</label>
                                        <br />
                                        <TextField onChange={e => { setUser({ ...user, name: e.target.value }) }} id="outlined-basic" label="Username" variant="outlined" style={{ marginBottom: "10px", width: "300px" }} />
                                        <br />
                                        <label style={{ fontFamily: "KungFuMasterSpaced" }}>Discord:</label>
                                        <br />
                                        <TextField onChange={e => { setUser({ ...user, discordname: e.target.value }) }} id="outlined-basic" label="Discord name" variant="outlined" style={{ marginBottom: "10px", width: "300px" }} />
                                        <br />
                                        <label style={{ fontFamily: "KungFuMasterSpaced" }}>Steam:</label>
                                        <br />
                                        <TextField onChange={e => { setUser({ ...user, steamname: e.target.value }) }} id="outlined-basic" label="Steam name" variant="outlined" style={{ marginBottom: "10px", width: "300px" }} />
                                        <br />
                                        <label style={{ fontFamily: "KungFuMasterSpaced" }}>Password:</label>
                                        <br />
                                        <TextField type={"password"} onChange={e => { setUser({ ...user, password: e.target.value }) }} id="outlined-basic" label="Password" variant="outlined" style={{ marginBottom: "10px", width: "300px" }} />
                                        <br />
                                        <Button variant="contained" color="success" onClick={() => inputSubmit()} style={{ margin: "1rem" }}>Sign Up</Button>
                                        <br />
                                        <p style={{ paddingBottom: "1rem", fontFamily: "times new roman" }}>have got a user :<Button color="secondary" href='/'>Sign in</Button></p>
                                    </Typography>

                                </Paper>
                            </Grid>
                        </Grid>

                    </div>
                
            </Container>
        </div>
    );
}

export default LoginSignUp;
