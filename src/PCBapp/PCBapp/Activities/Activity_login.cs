using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PCBapp.Activities
{
    [Activity(Label = "login_activity")]
    public class Activity_login : Activity
    {
        Button btnlogin;
        Button btnRegister;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_activity);
            btnlogin = FindViewById<Button>(Resource.Id.button1);
            btnlogin.Click += dologin;

            btnRegister = FindViewById<Button>(Resource.Id.button2);
            btnRegister.Click += doregister;
        }
        private void dologin(Object sender, EventArgs e)
        {
            bool valid = true;
            if(valid)
            {
                Intent newActivity = new Intent(this, typeof(MainActivity));
                this.StartActivity(newActivity);
            }
            else
            {

            }
        }
        private void doregister(object sender,EventArgs o)
        {
            Intent newActivity = new Intent(this, typeof(Activity_register));
            this.StartActivity(newActivity);
        }
    }
}