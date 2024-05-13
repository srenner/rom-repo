<script setup>
let settings = [
  {
    name: 'UniqueIdentifier',
    type: 'string',
    isRequired: true,
    value: ''
  },
  {
    name: 'RomRootFolder',
    type: 'string',
    isRequired: true,
    value: 'z:\\games'          
  },
  {
    name: 'SavesRootFolder',
    type: 'string',
    isRequired: false,
    value: 'z:\\saves'
  },
  {
    name: 'SaveStatesRootFolder',
    type: 'string',
    isRequired: false,
    value: 'z:\\savestates'
  },
  {
    name: 'SendAnalytics',
    type: 'bool',
    isRequired: false,
    value: '1'                  //defaults to 0
  },
  {
    name: 'UseApi',
    type: 'string',
    isRequired: false,
    value: '1'                  //defaults to 0
  },
  {
    name: 'ApiKey',
    type: 'string',
    isRequired: false,
    value: 'asdf'
  },
];

</script>
<template>
    <main>
        <h1 class='highlight'>=== Settings ===</h1>
        <div>
            <ul class="list-group">
                <li v-for="setting in settings" :key="setting.name" class="list-group-item">
                    <div class="d-flex align-items-start">


                        
                        <i  class="p-2 bi bi-stoplights"
                            :class="{   'text-success': !setting.isRequired || (setting.isRequired && setting.value), 
                                        'text-danger': setting.isRequired && !setting.value }"></i>
                        <i title="System Status" class="p-2 bi bi-pencil"></i>
                        <div class="p-2">
                            {{ setting.name }}
                        </div>
                        <div class="p-2">
                            {{ setting.value }}
                        </div>
                    </div>

                </li>
            </ul>
        </div>
    </main>
</template>

<style scoped>

</style>