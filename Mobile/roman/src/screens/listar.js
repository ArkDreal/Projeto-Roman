import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from '../services/api';

import { TouchableOpacity } from 'react-native-gesture-handler';

import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Projetos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaProjetos: []
        }
    };

    BuscarProjetos = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken')
            const resposta = await api.get('/Projetos', {
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            });
    
            const dadosApi =  await resposta.data;
            this.setState({ listaProjetos: dadosApi })
        } catch (error) {
            console.warn(error)
        }
    }

    componentDidMount() {
        this.BuscarProjetos();
    }

    render() {
        return (
            <View style={styles.main}>
                <View style={styles.organizar_titulo}>
                    <Text style={styles.titulo}>
                        Projetos
                    </Text>
                    <View style={styles.linha}></View>
                </View>
                <FlatList
                    contentContainerStyle={styles.lista}
                    data={this.state.listaProjetos}
                    keyExtractor={item => item.idProjeto}
                    renderItem={this.renderItem}
                />
            </View>
        )
    }

    renderItem = ({ item }) => (
        <View style={styles.container_lista}>
            <View style={styles.container_nomes}>
                <Text style={styles.nome}>{item.Titulo}</Text>
                <Text style={styles.nome_tema}>{item.Tema}</Text>
            </View>
            <Text style={styles.descricao}>
                {item.Descricao}
            </Text>
        </View>
    )

}


const styles = StyleSheet.create({

    main: {
        flex: 1,
        backgroundColor: '#321D5C',
        alignItems: 'center',
        justifyContent: 'space-evenly'
    },

    logo: {
        height: '30%',
        fontSize: 183.2,
        color: '#ffffff',
    },

    input: {
        color: '#fff',
        borderBottomColor: '#fff',
        borderBottomWidth: 2,
        width: '50%'
    },

    button: {
        width: '30%',
        height: '6%',
        borderWidth: 1,
        borderColor: '#fff',
        justifyContent: 'center',
        alignItems: 'center',
    },

    buttonText: {
        color: '#fff'
    },

    organizar_titulo: {
        justifyContent: 'space-between',
        alignItems: 'center',
        height: '10%',
        width: '100%'
    },

    titulo: {
        textTransform: 'uppercase',
        color: '#00ff00',
        fontSize: 40,
    },

    linha: {
        width: '70%',
        backgroundColor: '#00ff00',
        height: 2,
    },

    lista: {
        height: '15%',
        width: '100%',
        flex: 1

    }

});