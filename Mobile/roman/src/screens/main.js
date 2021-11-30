import React, {useState, useEffects, useEffect} from 'react';
import {FlatList, Image, StyleSheet, Text, View} from 'react-native';

import api from '../services/api';

import {TouchableOpacity} from 'react-native-gesture-handler';

import AsyncStorage from '@react-native-async-storage/async-storage';


export default function ListaEventos() {
    const[listaProjetos, setListaProjetos] = useState([]);

    function buscarProjetos() {
        const resposta = api.get('/Projetos');
        const dadosApi = resposta.data;
        setListaProjetos(dadosApi)
    }

    useEffect(buscarProjetos, [])

    return(
        <View>
            <Text>ahhhhhhhh</Text>
        </View>
    )
}