import React, { useState, useEffect } from "react";

import {
    StyleSheet,
    Text,
    View,
    TouchableOpacity,
    Image,
    ImageBackground,
    TextInput,
    Button
} from "react-native";

import AsyncStorage from '@react-native-async-storage/async-storage';
import { useNavigation } from "@react-navigation/native";

import api from '../services/api'

function Login() {
    const [email, setEmail] = useState('saulo@gmail.com');
    const [senha, setSenha] = useState('saulo123');
    const navigation = useNavigation()

    realizarLogin = async () => {
        console.warn("chegou aqui")
        //console.warn(`${email} ${senha}`)

        const resposta = await api.post('/Login', {
            email: email,
            senha: senha,
        });

        const token = resposta.data.token;
        console.warn(token)
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            console.warn('Chegou na api')
            navigation.navigate('Main')
        }

        console.warn(token)
    };

    return (
        <View
            style={styles.main}
        >
            <Image
                source={require('../../assets/img/Login.png')}
                style={styles.mainImgLogin}
            />
            <TextInput
                style={styles.inputLogin}
                placeholder='Email'
                placeholderTextColor="#472A82"
                keyboardType='email-address'
                onChange={(campo) => setEmail(campo)}
            />
            <TextInput
                style={styles.inputLogin}
                placeholder='Senha'
                placeholderTextColor='#472A82'
                keyboardType='default'
                onChange={(campo) => setSenha(campo)}
            />
            <TouchableOpacity
                style={styles.btnLogin}
                onPress={realizarLogin}
            >
                <Text style={styles.btnLoginText}>Entrar</Text>
            </TouchableOpacity>
        </View>

    );

}

const styles = StyleSheet.create({
    main: {
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
        backgroundColor: '#1D1136'
    },

    mainImgLogin: {
        tintColor: '#8C52FF',
        height: 226,
        width: 226,
        marginBottom: 50,
        marginTop: -40
    },

    inputLogin: {
        width: 250, //largura mesma do botao
        marginBottom: 40, //espacamento pra baixo
        fontSize: 18,
        color: '#472A82',
        backgroundColor: '#FFF',
        borderRadius: 8,
        textAlign: 'center'
    },

    btnLoginText: {
        fontSize: 12, //aumentar um pouco
        color: 'white', //mesma cor identidade
        letterSpacing: 6, //espacamento entre as letras 
        textTransform: 'uppercase'
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 42,
        width: 240,
        backgroundColor: '#8C52FF',
        borderColor: '#8C52FF',
        borderWidth: 1,
        borderRadius: 4,
        shadowOffset: { height: 1, width: 1 },
    },
})



export default Login