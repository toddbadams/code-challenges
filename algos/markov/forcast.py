import numpy as np
import yfinance as yf

class MarkovState:
    def __init__(self, name, probablities):
        self.name = name
        self.probabilities = probablities

class MarkovChain:
    def __init__(self, states):
        self.states = states
        self.currentState = states[0]
        self.list = [states[0].name]

    def transition(self):
        l = len(self.states)
        change = np.random.choice(l,replace=True,p=self.currentState.probabilities)    
        self.currentState = self.states[change]
        self.list.append(self.currentState.name)

    def probability(self, endState):
        count = 0
        for s in self.list:
            if(s == endState):
                count += 1
        return (count/len(self.list)) * 100


def SleepRunIcecream(MarkovState, MarkovChain, iterations):
    state1 = MarkovState("Sleep", [0.2,0.6,0.2])
    state2 = MarkovState("Run", [0.1,0.6,0.3])
    state3 = MarkovState("Icecream", [0.2,0.7,0.1])
    chain = MarkovChain([state1,state2,state3])
    for iterations in range(1,iterations):
        chain.transition()

    print("The probability of starting at state:'" + state1.name + "' and ending at state:'" + state1.name + "'= " + str(chain.probability(state1.name)) + "%")
    print("The probability of starting at state:'" + state1.name + "' and ending at state:'" + state2.name + "'= " + str(chain.probability(state2.name)) + "%")
    print("The probability of starting at state:'" + state1.name + "' and ending at state:'" + state3.name + "'= " + str(chain.probability(state3.name)) + "%")

#SleepRunIcecream(MarkovState, MarkovChain, 10000)

def Spy():
    spy = yf.download("SPY",start="2018-01-01", end="2018-12-31")
    data = spy[['Open', 'High', 'Low', 'Adj Close']].copy()
    data['pct_ret'] = data['Adj Close'].pct_change()
    data['state'] = data['pct_ret'].apply(lambda x: 'Up' if (x>0.001) else ('Down' if (x<-0.001) else 'Flat'))
    data['priorstate'] = data['state'].shift(1)
    states = data[['priorstate', 'state']]
    states_mat = states.groupby(['priorstate', 'state']).size().unstack()
    transitionMatrix = states_mat.apply(lambda x: x / float(x.sum()), axis=1)
    print(transitionMatrix)

Spy()