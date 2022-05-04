package com.example.trabalhoswebservice;

import androidx.appcompat.app.AppCompatActivity;

import android.media.Image;
import android.os.Bundle;
import android.util.Xml;
import android.view.View;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;

import java.io.BufferedReader;
import java.io.InputStream;
import android.os.AsyncTask;
import android.widget.Toast;

import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;


public class MainActivity extends AppCompatActivity {

    TextView textView;
    TextView textpergunta;
    TextView textViewUrl;
    String UlrAdress = "https://api.chucknorris.io/jokes/random";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        textView = (TextView)findViewById(R.id.textviewDataCriacao);
        textView.setText(" Aguardando informações ");
        textpergunta = (TextView)findViewById(R.id.textViewResposta);
        textpergunta.setText(" Aguardando informações ");
        textViewUrl = (TextView)findViewById(R.id.textViewUrl);
        textViewUrl.setText(" Aguardando informações ");
    }

    private JSONObject doGetService(){
        String resposta = "";
        JSONObject jsonObject = new JSONObject();
        try{
            URL url = new URL(this.UlrAdress);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("GET");
            connection.setConnectTimeout(3000);
            connection.setReadTimeout(3000);
            connection.connect();
            if(connection.getResponseCode() == HttpURLConnection.HTTP_OK){
                InputStream inputStream = connection.getInputStream();

                BufferedReader br = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                StringBuilder sb = new StringBuilder();
                String line;
                while ((line = br.readLine()) != null) {
                    sb.append(line+"\n");
                }
                br.close();

                jsonObject = new JSONObject(sb.toString());

                inputStream.close();
            }
            connection.disconnect();

        }catch (Exception e){
            resposta = e.getMessage();
            e.printStackTrace();
        }
        return jsonObject;
    }


    public  void ButtonPress(View view){
         new ConnectionTask().execute();
    }


    private class ConnectionTask extends AsyncTask<String,Void,String>{
        @Override
        protected String doInBackground(String... strings) {
            JSONObject jsonObject = new JSONObject();
            try {

                jsonObject = doGetService();

            }catch (Exception e){
                Toast.makeText(MainActivity.this,e.toString(),Toast.LENGTH_LONG);
            }

            return jsonObject.toString();
        }



        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            String strCreateAt, strIconUrl, strUrl, strValue;

            JSONObject jsonObject = null;
            try {
                jsonObject = new JSONObject(s);
                strCreateAt = jsonObject.getString("created_at");
                strIconUrl  = jsonObject.getString("icon_url");
                strUrl  = jsonObject.getString("url");
                strValue = jsonObject.getString("value");

                textView.setText(strCreateAt);
                textpergunta.setText(strValue);
                textViewUrl.setText(strUrl);
            } catch (JSONException e) {
                e.printStackTrace();
                Toast.makeText(MainActivity.this,s,Toast.LENGTH_LONG);
            }

        }
    }

}