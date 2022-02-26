#include<iostream>
#include<vector>
using namespace std;

int broiBaloni;
vector<int> baloni;

int broiPitanki;

int otgovori[100010];
int broiOtgovori;

void premahni(int poziciq){
    baloni.erase(baloni.begin() + poziciq);
}

void vmakni(int poziciq, int cvqt){
    baloni.insert(baloni.begin() + poziciq, cvqt);
}

void zameni(int poziciq, int cvqt){
    baloni[poziciq] = cvqt;
}

int cvetnost(){
    int brCvetnost = 1;
    int predishen = baloni[0];

    for(unsigned int i = 1; i < baloni.size(); i++){
        if(baloni[i] != predishen){
            brCvetnost++;
        }
        predishen = baloni[i];
    }

    return brCvetnost;
}

int main(){
    cin>>broiBaloni;

    for(int i = 0; i < broiBaloni; i++){
        int balonche;
        cin>>balonche;
        baloni.push_back(balonche);
    }

    cin>>broiPitanki;

    for(int i = 0; i < broiPitanki; i++){
        int tip;
        cin>>tip;
        if(tip == 1){
            int naKoqPoziciq;
            cin>>naKoqPoziciq;
            premahni(naKoqPoziciq - 1);
        }else{
            if(tip == 2){
                int poziciq;
                int cvqt;
                cin>>poziciq>>cvqt;
                vmakni(poziciq - 1, cvqt);
            }else{
                if(tip == 3){
                    int poziciq;
                    int cvqt;
                    cin>>poziciq>>cvqt;
                    zameni(poziciq - 1, cvqt);
                }else{
                    int cvt = cvetnost();
                    otgovori[broiOtgovori] = cvt;
                    broiOtgovori++;
                }
            }
        }
    }

    for(int i = 0; i < broiOtgovori; i++){
        cout<<otgovori[i]<<endl;
    }

    return 0;
}
