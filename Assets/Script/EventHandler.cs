using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventHandler
{
    public delegate void LoginSuccess(bool status);
    public delegate void RegisterSuccess(bool status);
    public static LoginSuccess CheckLogin;
    public static RegisterSuccess CheckRegister;
}