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
import { FetchPost, FetchGet } from "../FetchHelper";
import GroupCatalog from '../Groups/GroupCatalog';

function Login() {

    const [user, setUser] = useState({
        name: "",
        password: ""
    });
    const [responseStatusFail, setResponseStatusFail] = useState(false)
    const [login, setLogin] = useState(false)
    async function inputSubmit() {
        if (user.name.length<1 || user.password.length<1) {
            return;
        }
        console.log(user);
        const status = await FetchPost(user);

        if (status.status != 200) {
            setResponseStatusFail(true)
        } else {
            const userData = await status.json().then((data) => data)
            sessionStorage.setItem("userId", JSON.stringify(userData.userId));
            sessionStorage.setItem("userName", JSON.stringify(userData.name));
            console.log(sessionStorage.getItem("userId"))
            setLogin(true)
        }
    }


    return (
        <div>
            <div style={{ paddingTop: "2rem", textAlign: "center" }}></div>
            <Container>

                {!login &&
                    <div>
                        <Typography fontSize={90} align="center" fontWeight={""} style={{ color: "red", fontFamily: "wasted" }}>GameDay</Typography>
                        <Grid container>
                            <Grid item xs={3}>

                            </Grid>
                            <Grid item xs={6}>
                                <Paper>
                                    <Typography align="center">
                                        <Typography fontSize={30} align="center" style={{ padding: "1rem", fontFamily: "KungFuMasterSpaced", fontWeight: "bold" }}>Login</Typography>
                                        {responseStatusFail &&
                                            <div style={{color:"red"}}>Wrong User Login</div>
                                        }
                                        <label style={{ fontFamily: "KungFuMasterSpaced" }}>UserName:</label>
                                        <br />
                                        <TextField onChange={e => { setUser({ ...user, name: e.target.value }) }} id="outlined-basic" label="Username" variant="outlined" style={{ marginBottom: "10px", width: "300px" }} />
                                        <br />
                                        <label style={{ fontFamily: "KungFuMasterSpaced" }}>Password:</label>
                                        <br />
                                        <TextField type={"password"} onChange={e => { setUser({ ...user, password: e.target.value }) }} id="outlined-basic" label="Password" variant="outlined" style={{ marginBottom: "10px", width: "300px" }} />
                                        <br />
                                        <Button variant="contained" color="success" onClick={() => inputSubmit()} style={{ margin: "1rem" }}>Login</Button>
                                        <br />
                                        <p style={{ paddingBottom: "1rem", fontFamily: "times new roman" }}>haven't got a user :<Button color="secondary" href='/Signup'>Sign up</Button></p>
                                    </Typography>

                                </Paper>
                            </Grid>
                        </Grid>

                        
                    </div>
                }{login &&
                    <div>
                        <GroupCatalog></GroupCatalog>
                    </div>
                }
            </Container>
        </div>
    );
}

export default Login;
